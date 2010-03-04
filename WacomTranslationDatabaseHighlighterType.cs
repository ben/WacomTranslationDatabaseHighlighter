using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace WacomTranslationDatabaseHighlighter
{
    internal static class WacomTranslationDatabaseHighlighterClassificationKeyDefinition
    {
        #region Classification types
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("wacom.tdb.key")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterKeyType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("wacom.tdb.value")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterValueType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("wacom.tdb.separator")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterSeparatorType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("wacom.tdb.error")]
        internal static ClassificationTypeDefinition WacomTranslationDatabaseHighlighterErrorType = null;
        #endregion
    }
}
