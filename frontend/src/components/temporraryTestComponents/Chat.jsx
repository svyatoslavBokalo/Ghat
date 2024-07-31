import { useState, useEffect, useRef } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { useLocation } from "react-router-dom";

import ChatWindow from "./ChatWindow";
import ChatInput from "./ChatInput";

const Chat = () => {
  const [connection, setConnection] = useState(null);
  const [chat, setChat] = useState([]);
  const latestChat = useRef(null);
  const location = useLocation();
  const pathParts = location.pathname.split("/");
  const groupID = pathParts[pathParts.length - 1];

  latestChat.current = chat;

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7090/hubs/chat")
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() => {
          console.log("Connected!");

          connection.on("ReceiveMessage", (message) => {
            console.log("Message received:", message);
            const updatedChat = [...latestChat.current];
            updatedChat.push(message);

            setChat(updatedChat);
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);

  // const sendMessage = async (user, message) => {
  //   const chatMessage = {
  //     user,
  //     message,
  //   };

  //   if (connection && connection.state === "Connected") {
  //     try {
  //       await connection.send("SendMessage", chatMessage);
  //     } catch (e) {
  //       console.log(e);
  //     }
  //   } else {
  //     alert("No connection to server yet.");
  //   }
  // };

  const enterGroup = async (userName, groupName) => {
    if (connection && connection.state === "Connected") {
      try {
        await connection.invoke("Enter", userName, groupName);
      } catch (e) {
        console.log(e);
      }
    } else {
      alert("No connection to server yet.");
    }
  };

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() => {
          console.log("Connected!");

          // Add the user to the group after connecting
          enterGroup("HARDCODED_UserName", groupID); // Replace 'YourUserName' with actual user's name

          connection.on("ReceiveMessage", (message) => {
            console.log("Message received:", message);
            const updatedChat = [...latestChat.current];
            updatedChat.push(message);

            setChat(updatedChat);
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);

  const sendMessageToGroup = async (user, message, groupName) => {
    const chatMessage = {
      user,
      message,
      groupName,
    };

    if (connection && connection.state === "Connected") {
      try {
        await connection.invoke("SendMessage", chatMessage);
      } catch (e) {
        console.log(e);
      }
    } else {
      alert("No connection to server yet.");
    }
  };

  return (
    <div>
      <ChatInput groupID={groupID} sendMessage={sendMessageToGroup} />
      <hr />
      <ChatWindow chat={chat} />
    </div>
  );
};

export default Chat;
