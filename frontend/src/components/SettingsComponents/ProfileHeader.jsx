import { Grid, IconButton, Typography } from "@mui/material";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import { useNavigate } from "react-router-dom";
import MoreHorizOutlinedIcon from "@mui/icons-material/MoreHorizOutlined";
import { useState } from "react";
import palette from "../../theme/palette.js";
import typography from "../../theme/typography.js";
import { PROFILE_HEADER_TITLES } from "../../app/constants.js";
import SubMenu from "../SubMenu/SubMenu.jsx";

const ProfileHeader = ({ title }) => {
  const navigate = useNavigate();
  const isUserInfoPage = title === PROFILE_HEADER_TITLES.USER_INFO;
  const isNewChatPage = title === PROFILE_HEADER_TITLES.NEW_CHAT;
  // let isSettingsPage = title === PROFILE_HEADER_TITLES.SETTINGS;

  const [isDotsClicked, setIsDotsClicked] = useState(false);
  const dotsActions = ["Поскаржитись", "Заблокувати"];
  const handleGoBack = () => {
    navigate(-1);
  };

  const onDotsClick = () => {
    setIsDotsClicked((prevState) => !prevState);
  };

  return (
    <Grid
      container
      justifyContent="start"
      alignItems="center"
      sx={{ paddingBottom: "27px", paddingTop: " 23px" }}
    >
      <IconButton
        edge="start"
        aria-label="back"
        onClick={handleGoBack}
        sx={{ marginLeft: "12px" }}
      >
        <ArrowBackIcon sx={{ color: palette.midnight }} />
      </IconButton>
      {(isUserInfoPage || isNewChatPage) && (
        <Typography sx={{ ...typography.body1, color: palette.grey["200"] }}>
          Назад
        </Typography>
      )}

      <Typography
        sx={{
          flex: 1,
          color: palette.primary.main,
          marginLeft: "-20px",
          ...typography.body1,
        }}
      >
        {title}
      </Typography>

      {isUserInfoPage && (
        <div style={{ position: "relative" }}>
          <MoreHorizOutlinedIcon
            sx={{
              color: palette.midnight,
              height: "32px",
              width: "32px",
              cursor: "pointer",
              marginRight: "18px",
            }}
            onClick={onDotsClick}
          />
          {isDotsClicked && <SubMenu props={dotsActions} />}
        </div>
      )}
    </Grid>
  );
};
export default ProfileHeader;
