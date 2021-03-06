﻿using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Windows;

namespace WacomTranslationDatabaseHighlighter
{
	#region Key Format definition
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "wacom.tdb.key")]
	[Name("wacom.tdb.key")]
	internal sealed class WacomTranslationDatabaseHighlighterKeyFormat : ClassificationFormatDefinition
	{
		public WacomTranslationDatabaseHighlighterKeyFormat()
		{
			this.ForegroundColor = Colors.Blue;
			this.TextDecorations = System.Windows.TextDecorations.Underline;
		}
	}
	#endregion //Format definition

	#region Value Format definition
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "wacom.tdb.value")]
	[Name("wacom.tdb.value")]
	internal sealed class WacomTranslationDatabaseHighlighterValueFormat : ClassificationFormatDefinition
	{
		public WacomTranslationDatabaseHighlighterValueFormat()
		{
			this.ForegroundColor = Colors.DarkRed;
		}
	}
	#endregion //Format definition

	#region Separator Format definition
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "wacom.tdb.separator")]
	[Name("wacom.tdb.separator")]
	internal sealed class WacomTranslationDatabaseHighlighterSeparatorFormat : ClassificationFormatDefinition
	{
		public WacomTranslationDatabaseHighlighterSeparatorFormat()
		{
			this.BackgroundColor = Colors.Yellow;
			this.TextDecorations = System.Windows.TextDecorations.Strikethrough;
		}
	}
	#endregion //Format definition

	#region Error Format definition
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "wacom.tdb.error")]
	[Name("wacom.tdb.error")]
	[Order(After = Priority.Default)] //set the priority to be after the default classifiers
	internal sealed class WacomTranslationDatabaseHighlighterErrorFormat : ClassificationFormatDefinition
	{
		public WacomTranslationDatabaseHighlighterErrorFormat()
		{
            this.TextDecorations = new System.Windows.TextDecorationCollection()
            {
                new TextDecoration()
                {
                    Pen = new Pen(new SolidColorBrush(Colors.Red), 3),
                    PenThicknessUnit = TextDecorationUnit.FontRecommended,
                }
            };
		}
	}
	#endregion //Format definition
}
