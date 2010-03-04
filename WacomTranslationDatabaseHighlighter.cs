using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Diagnostics;

namespace WacomTranslationDatabaseHighlighter
{
    internal sealed class Components
    {
        // Map ".utf8" extension to the content-type
        [Export]
        [FileExtension(".utf8")]
        [ContentType("wacom.tdb")]
        internal FileExtensionToContentTypeDefinition utf8FileExtensionDefinition = null;

        // Metadata about content type
        [Export]
        [Name("wacom.tdb")]
        [BaseDefinition("text")]
        internal static ContentTypeDefinition utf8ContentTypeDefinition = null;
    }


    #region Provider definition
    /// <summary>
    /// This class causes a classifier to be added to the set of classifiers. Since 
    /// the content type is set to "text", this classifier applies to all text files
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [ContentType("wacom.tdb")]
    internal class WacomTranslationDatabaseHighlighterProvider : IClassifierProvider
    {
        /// <summary>
        /// Import the classification registry to be used for getting a reference
        /// to the custom classification type later.
        /// </summary>
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null; // Set via MEF

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<WacomTranslationDatabaseHighlighter>(delegate { return new WacomTranslationDatabaseHighlighter(ClassificationRegistry); });
        }
    }
    #endregion //provider def

    #region Classifier
    /// <summary>
    /// Classifier that classifies all text as an instance of the OrinaryClassifierType
    /// </summary>
    class WacomTranslationDatabaseHighlighter : IClassifier
    {
        // Types for key and value
        IClassificationType _keyType;
        IClassificationType _valType;
        IClassificationType _sepType;
        IClassificationType _errType;

        internal WacomTranslationDatabaseHighlighter(IClassificationTypeRegistryService registry)
        {
            _keyType = registry.GetClassificationType("wacom.tdb.key");
            _valType = registry.GetClassificationType("wacom.tdb.value");
            _sepType = registry.GetClassificationType("wacom.tdb.separator");
            _errType = registry.GetClassificationType("wacom.tdb.error");
        }

        /// <summary>
        /// This method scans the given SnapshotSpan for potential matches for this classification.
        /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
        /// </summary>
        /// <param name="trackingSpan">The span currently being classified</param>
        /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification</returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            //create a list to hold the results
            List<ClassificationSpan> classifications = new List<ClassificationSpan>();

            // Split the line with the first tab character
            string text = span.GetText();
            int totalLength = text.Length;
            int tabPosition = text.IndexOf('\t');

            if (tabPosition < 0)
            {
                // No tab, error the entire line
                return new List<ClassificationSpan>
                {
                    new ClassificationSpan(span, _errType)
                };
            }

            if (tabPosition == 0)
            {
                // Tab at start of line, error just the tab
                classifications.Add(new ClassificationSpan(
                    new SnapshotSpan(span.Snapshot, new Span(span.Start, 1)),
                    _errType));
            }

            if (tabPosition > 0)
            {
                classifications.Add(new ClassificationSpan(
                    new SnapshotSpan(span.Snapshot, new Span(span.Start, tabPosition)),
                    _keyType));
                classifications.Add(new ClassificationSpan(
                    new SnapshotSpan(span.Snapshot, new Span(span.Start + tabPosition, 1)),
                    _sepType));
                classifications.Add(new ClassificationSpan(
                    new SnapshotSpan(span.Snapshot,
                        new Span(span.Start + tabPosition + 1, totalLength - tabPosition - 1)),
                    _valType));
            }

            int secondtabPosition = text.IndexOf('\t', tabPosition+1);
            if (secondtabPosition > 0)
            {
                // Too many tabs, error starting with the second
                classifications.Add(new ClassificationSpan(
                    new SnapshotSpan(span.Snapshot,
                        new Span(span.Start + secondtabPosition, totalLength - secondtabPosition)),
                    _errType));
            }

            return classifications;
        }

#pragma warning disable 67
        // This event gets raised if a non-text change would affect the classification in some way,
        // for example typing /* would cause the classification to change in C# without directly
        // affecting the span.
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
#pragma warning restore 67
    }
    #endregion //Classifier
}
