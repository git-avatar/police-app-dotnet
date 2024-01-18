// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoliceApp.WPFClient
{
    /// <summary>
    /// EditorServiceViaWindow class.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// EditStation method that will pop up a new editor window while editing an instance.
        /// </summary>
        /// <param name="station">StationVM instance to be edited.</param>
        /// <returns>Bool variable signifying if the Station was edited or not.</returns>
        public bool EditStation(StationVM station)
        {
            EditorWindow win = new EditorWindow(station);
            return win.ShowDialog() ?? false;
        }
    }
}
