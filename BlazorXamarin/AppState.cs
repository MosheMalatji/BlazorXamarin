using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BlazorXamarin
{
    public class AppState
    {
        private TodoItemDatabase _todoDatabase;

        public TodoItemDatabase TodoDatabase
        {
            get
            {
                if (_todoDatabase == null)
                {
                    _todoDatabase =
                        new TodoItemDatabase(
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"),
                            dbChanged: NotifyStateChanged); 
                }
                return _todoDatabase;
            }
        }

        public int Counter { get; set; }
        public event Func<Task> OnChange;
        private async Task NotifyStateChanged() => await OnChange?.Invoke();
    }
}
