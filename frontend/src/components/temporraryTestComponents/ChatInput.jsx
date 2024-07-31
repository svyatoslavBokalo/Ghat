import { useState } from "react";

const ChatInput = ({ sendMessage, groupID }) => {
  const [user, setUser] = useState("");
  const [message, setMessage] = useState("");

  const onSubmit = (e) => {
    e.preventDefault();

    const isUserProvided = user && user !== "";
    const isMessageProvided = message && message !== "";

    if (isUserProvided && isMessageProvided) {
      sendMessage(user, message, groupID);
    } else {
      alert("Please insert an user and a message.");
    }
  };

  const onUserUpdate = (e) => {
    setUser(e.target.value);
  };

  const onMessageUpdate = (e) => {
    setMessage(e.target.value);
  };

  return (
    <form onSubmit={onSubmit}>
      <label htmlFor="user">
        User:
        <br />
        <input
          id="user"
          type="text"
          name="user"
          value={user}
          onChange={onUserUpdate}
        />
      </label>
      <br />
      <label htmlFor="message">
        Message:
        <br />
        <input
          type="text"
          id="message"
          name="message"
          value={message}
          onChange={onMessageUpdate}
        />
      </label>
      <br />
      <br />
      <button type="submit">Submit</button>
    </form>
  );
};

export default ChatInput;
