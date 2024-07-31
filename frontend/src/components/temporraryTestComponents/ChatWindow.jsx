import Message from "./Message";

const ChatWindow = ({ chat }) => {
  const myChat = chat.map((m) => (
    <Message
      key={Date.now() * Math.random()}
      user={m.user}
      message={m.message}
    />
  ));

  return <div>{myChat}</div>;
};

export default ChatWindow;
