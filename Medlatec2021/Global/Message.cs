using System.Collections.Generic;

namespace MEDLATEC2019.Global
{
    public class Message
    {
        public enum MessageTypeEnum
        {
            Message = 0,
            Error = 1,
            Notice = 2
        }

        public Message()
        {
        }

        public Message(MessageTypeEnum messageType)
        {
            MessageType = messageType;
        }

        public void Clear()
        {
            ListMessage.Clear();
            MessageType = MessageTypeEnum.Message;
        }

        public List<string> ListMessage { get; } = new List<string>();

        public string MessageTypeName => MessageType.ToString().ToLower();

        public MessageTypeEnum MessageType { get; set; }
    }
}