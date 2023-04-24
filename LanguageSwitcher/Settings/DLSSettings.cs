using LDS.Data;
using System;
using System.Diagnostics;

namespace DLS.Settings {
    
    
    // Этот класс позволяет обрабатывать определенные события в классе параметров:
    //  Событие SettingChanging возникает перед изменением значения параметра.
    //  Событие PropertyChanged возникает после изменения значения параметра.
    //  Событие SettingsLoaded возникает после загрузки значений параметров.
    //  Событие SettingsSaving возникает перед сохранением значений параметров.
    internal sealed partial class DLSSettings {
        
        public DLSSettings() {
            // Для добавления обработчиков событий для сохранения и изменения параметров раскомментируйте приведенные ниже строки:

            this.SettingChanging += this.SettingChangingEventHandler;

            this.SettingsSaving += this.SettingsSavingEventHandler;

        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Добавьте здесь код для обработки события SettingChangingEvent.

            Debug.WriteLine("["+ DateTime.Now.ToLongTimeString() + "] Changing: Current Value of Return To is : " + ReturnTo);

        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Добавьте здесь код для обработки события SettingsSaving.

            Debug.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] Saving: Current Value of Return To is : " + ReturnTo);
        }
    }
}
