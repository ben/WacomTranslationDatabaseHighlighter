using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace WacomTranslationDatabaseHighlighter
{
	#region Format definition
	/// <summary>
	/// Defines an editor format for the WacomTranslationDatabaseHighlighter type that has a purple background
	/// and is underlined.
	/// </summary>
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "WacomTranslationDatabaseHighlighter.Key")]
	[Name("WacomTranslationDatabaseHighlighter.KeyFormat")]
	[UserVisible(true)] //this should be visible to the end user
	[Order(Before = Priority.Default)] //set the priority to be after the default classifiers
	internal sealed class WacomTranslationDatabaseHighlighterKeyFormat : ClassificationFormatDefinition
	{
		/// <summary>
		/// Defines the visual format for the "WacomTranslationDatabaseHighlighter" classification type
		/// </summary>
		public WacomTranslationDatabaseHighlighterKeyFormat()
		{
			this.DisplayName = "WacomTranslationDatabaseHighlighter"; //human readable version of the name
			this.BackgroundColor = Colors.LightBlue;
			this.TextDecorations = System.Windows.TextDecorations.Underline;
		}
	}
	#endregion //Format definition

	#region Value Format definition
	/// <summary>
	/// Defines an editor format for the WacomTranslationDatabaseHighlighter type that has a purple background
	/// and is underlined.
	/// </summary>
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "WacomTranslationDatabaseHighlighter.Value")]
	[Name("WacomTranslationDatabaseHighlighter.ValueFormat")]
	[UserVisible(true)] //this should be visible to the end user
	[Order(Before = Priority.Default)] //set the priority to be after the default classifiers
	internal sealed class WacomTranslationDatabaseHighlighterValueFormat : ClassificationFormatDefinition
	{
		/// <summary>
		/// Defines the visual format for the "WacomTranslationDatabaseHighlighter" classification type
		/// </summary>
		public WacomTranslationDatabaseHighlighterValueFormat()
		{
			this.DisplayName = "WacomTranslationDatabaseHighlighter"; //human readable version of the name
			this.BackgroundColor = Colors.LightGreen;
		}
	}
	#endregion //Format definition

	#region Separator Format definition
	/// <summary>
	/// Defines an editor format for the WacomTranslationDatabaseHighlighter type that has a purple background
	/// and is underlined.
	/// </summary>
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "WacomTranslationDatabaseHighlighter.Separator")]
	[Name("WacomTranslationDatabaseHighlighter.SeparatorFormat")]
	[UserVisible(true)] //this should be visible to the end user
	[Order(Before = Priority.Default)] //set the priority to be after the default classifiers
	internal sealed class WacomTranslationDatabaseHighlighterSeparatorFormat : ClassificationFormatDefinition
	{
		/// <summary>
		/// Defines the visual format for the "WacomTranslationDatabaseHighlighter" classification type
		/// </summary>
		public WacomTranslationDatabaseHighlighterSeparatorFormat()
		{
			this.DisplayName = "WacomTranslationDatabaseHighlighter"; //human readable version of the name
			this.BackgroundColor = Colors.Yellow;
			this.TextDecorations = System.Windows.TextDecorations.Strikethrough;
		}
	}
	#endregion //Format definition

	#region Error Format definition
	/// <summary>
	/// Defines an editor format for the WacomTranslationDatabaseHighlighter type that has a purple background
	/// and is underlined.
	/// </summary>
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "WacomTranslationDatabaseHighlighter.Error")]
	[Name("WacomTranslationDatabaseHighlighter.ErrorFormat")]
	[UserVisible(true)] //this should be visible to the end user
	[Order(After = Priority.Default)] //set the priority to be after the default classifiers
	internal sealed class WacomTranslationDatabaseHighlighterErrorFormat : ClassificationFormatDefinition
	{
		/// <summary>
		/// Defines the visual format for the "WacomTranslationDatabaseHighlighter" classification type
		/// </summary>
		public WacomTranslationDatabaseHighlighterErrorFormat()
		{
			this.DisplayName = "WacomTranslationDatabaseHighlighter"; //human readable version of the name
			this.BackgroundColor = Colors.OrangeRed;
		}
	}
	#endregion //Format definition
}
