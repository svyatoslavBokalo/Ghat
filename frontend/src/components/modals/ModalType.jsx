const modalType = {
  deleteChatWithUser: (
    <>
      <h3>Впевнений, що хочеш видалити чат з @username?</h3>
      <button type="button" className="delete-chat">
        Видалити чат
      </button>
      <button type="button" className="block-delete">
        Видалити чат і заблокувати користувача
      </button>
    </>
  ),

  deleteChat: (
    <>
      <h3>Впевнений, що хочеш видалити чат Назва чату?</h3>
      <button className="delete-chat">Видалити чат</button>
    </>
  ),
  deleteGroup: (
    <>
      <h3 className="delete-gtoup">
        Впевнений, що хочеш видалити свою групу?
        <span>Повідомлення зникнуть для всіх учасників </span>
      </h3>
      <button className="delete-chat">Видалити групу назавжди</button>
    </>
  ),
  logOut: (
    <>
      <h3>Точно хочеш вийти з аккаунту?</h3>
      <button className="delete-chat">Вийти</button>
    </>
  ),
  deleteAccaunt: (
    <>
      <h3 id="exit-accaunt" className=" delete-gtoup">
        Впевнений, що хочеш видалити аккаунт?
        <span>Це незворотня дія</span>
      </h3>
      <button className="delete-chat">Видалити</button>
    </>
  ),
};
/* prettier-ignore */

export default  modalType ;
