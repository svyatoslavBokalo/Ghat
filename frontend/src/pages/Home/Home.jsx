import { Link } from "react-router-dom";
import "./Home.scss";

function Home() {
  return (
    <div className="container">
      <div className="search">
        <input type="text" placeholder="Search for messages or users" />
      </div>
      <div className="chats">
        <ChatItem
          chatId="001"
          title="Особистий контакт"
          subtitle="👏 IOS 13 Design Kit. Turn your ideas into incredible wor..."
        />
        <ChatItem
          chatId="002"
          title="Чат"
          subtitle="👏 IOS 13 Design Kit. Turn your ideas into incredible wor..."
        />
        <ChatItem
          chatId="003"
          title="Особистий контакт"
          subtitle="👏 IOS 13 Design Kit. Turn your ideas into incredible wor..."
        />
        <ChatItem
          chatId="004"
          title="Чат"
          subtitle="👏 IOS 13 Design Kit. Turn your ideas into incredible wor..."
        />
      </div>
    </div>
  );
}

function ChatItem({ title, subtitle, chatId }) {
  return (
    <Link
      to={`/chat/${chatId}`}
      style={{ textDecoration: "none", color: "inherit" }}
    >
      <div className="chat-item">
        <div className="avatar">
          {/* Тут може бути аватар користувача або інший зображення */}
        </div>
        <div className="chat-details">
          <div className="chat-title">{title}</div>
          <div className="chat-subtitle">{subtitle}</div>
        </div>
      </div>
    </Link>
  );
}

export default Home;
