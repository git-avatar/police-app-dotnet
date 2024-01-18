// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPF.UI
{
    using PoliceApp.WPF.BL;
    using PoliceApp.WPF.Data;

    /// <summary>
    /// EditorServiceViaWindow which is resposible for.
    /// </summary>
    internal class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// EditStation method which show how to edit a player.
        /// </summary>
        /// <param name="station">Station to be edited.</param>
        /// <returns>Return value of the ShowDialog.</returns>
        public bool EditStation(StationModel station)
        {
            EditorWindow editorWindow = new EditorWindow(station);
            return editorWindow.ShowDialog() ?? false;
        }
    }
}
