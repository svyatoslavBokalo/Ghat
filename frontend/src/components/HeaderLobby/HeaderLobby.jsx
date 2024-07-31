import { Button } from "@mui/material";
import HeaderLobbyIcons from "../HeaderLobbyIcons/HeaderLobbyIcons";
import HeaderLobbyText from "../HeaderLobbyText/HeaderLobbyText";

const HeaderLobby = () => {
  return (
    <div>
      <HeaderLobbyIcons />
      <HeaderLobbyText />

      <div style={{ margin: "55px 0 92px" }}>
        <Button
          variant="contained"
          sx={{
            width: "140px",
            height: "140px",
            borderRadius: "50%",
            marginRight: "10px",
          }}
        >
          Здивуй <br />
          мене
        </Button>

        <Button
          variant="contained"
          sx={{
            width: "140px",
            height: "140px",
            borderRadius: "50%",
          }}
        >
          Створити тему
        </Button>
      </div>
    </div>
  );
};

export default HeaderLobby;
