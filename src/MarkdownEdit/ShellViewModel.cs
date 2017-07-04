﻿using System.IO;
using Infrastructure;
using Prism.Events;
using Prism.Mvvm;

namespace MarkdownEdit
{
    public class ShellViewModel : BindableBase
    {
        private const string ProgramName = "MARKDOWN EDIT";

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<FileNameChangedEvent>().Subscribe(fileName => DocumentName = Path.GetFileName(fileName));
            eventAggregator.GetEvent<DocumentModifiedChangedEvent>().Subscribe(flag => DocoumentModified = flag ? "*" : "");
        }


        private string _appTitle = ProgramName;

        public string AppTitle
        {
            get => _appTitle;
            set => SetProperty(ref _appTitle, value);
        }

        private string _documentName = string.Empty;

        public string DocumentName
        {
            get => _documentName;
            set => SetProperty(ref _documentName, value, UpdateAppTitle);
        }

        private string _docoumentModified = string.Empty;

        public string DocoumentModified
        {
            get => _docoumentModified;
            set => SetProperty(ref _docoumentModified, value, UpdateAppTitle);
        }

        private void UpdateAppTitle()
        {
            AppTitle = $"{ProgramName} - {DocoumentModified}{DocumentName}";
        }
    }
}