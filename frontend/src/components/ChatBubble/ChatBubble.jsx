import "./ChatBubble.scss";

function ChatBubble({ message }) {
  return (
    <div
      className={`chat-bubble ${
        message.author === "Моніка Геллер" ? "left" : "right"
      }`}
    >
      <div className="chat-author">{message.author}</div>
      <div className="chat-text">{message.text}</div>
      <div className="chat-time">{message.time}</div>
    </div>
  );
}

export default ChatBubble;
