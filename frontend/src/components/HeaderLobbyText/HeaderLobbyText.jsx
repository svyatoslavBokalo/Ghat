import SearchField from "../SearchField/SearchField";

const HeaderLobbyText = () => {
  return (
    <div>
      {" "}
      <strong> Привіт, username!</strong>{" "}
      <div> Про що хочеш поговорити сьогодні?:) </div>
      <SearchField />
    </div>
  );
};

export default HeaderLobbyText;
