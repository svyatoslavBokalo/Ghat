import ChatBubble from "../ChatBubble/ChatBubble";
import "./MessagesArea.scss";

const messages = [
  { id: "1", author: "Моніка Геллер", text: "Do you like it?", time: "11:45" },
  {
    id: "2",
    author: "Флеш",
    text: "Lorem ipsum dolor sit amet consectetur.",
    time: "11:45",
  },
  { id: "3", author: "Моніка Геллер", text: "Do you like it?", time: "11:45" },
  {
    id: "4",
    author: "Флеш",
    text: "Lorem ipsum dolor sit amet consectetur.",
    time: "11:45",
  },
  { id: "5", author: "Моніка Геллер", text: "Do you like it?", time: "11:45" },
  {
    id: "6",
    author: "Флеш",
    text: "Lorem ipsum dolor sit amet consectetur.",
    time: "11:45",
  },
];

function MessagesArea() {
  return (
    <div className="msgs-area">
      {messages.map((message) => (
        <ChatBubble key={message.id} message={message} />
      ))}
    </div>
  );
}
export default MessagesArea;
