using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace WacomTranslationDatabaseHighlighter
{
    internal static class WacomTranslationDatabaseHighlighterClassificationKeyDefinition
    {
        /// <summary>
        /// Defines the "WacomTranslationDatabaseHighlighter" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("WacomTranslationDatabaseHighlighter.Key")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterKeyType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("WacomTranslationDatabaseHighlighter.Value")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterValueType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("WacomTranslationDatabaseHighlighter.Separator")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterSeparatorType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("WacomTranslationDatabaseHighlighter.Error")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterErrorType = null;
    }
}
