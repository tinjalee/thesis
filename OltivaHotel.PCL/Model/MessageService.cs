using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OltivaHotel.PCL.Model
{
    public static class MessageService
    {
        public static Stack<string> MessageStack = new Stack<string>();
        public static ObservableCollection<MenuItem> StaticMenuItemList = new ObservableCollection<MenuItem>();

        public static void PassMessage(string message)
        {
            if (MessageStack == null)
                MessageStack = new Stack<string>();

            MessageStack.Push(message);
        }

        public static string ReadMessage()
        {
            if (MessageStack != null && MessageStack.Count > 0)
            {
                return MessageStack.Pop();
            }
            return "";
        }

        public static void Clear()
        {
            StaticMenuItemList.Clear();
            MessageStack.Clear();
        }
    }
}