import { Button, Typography } from "@mui/material";
import "./SettingsFooter.scss";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import palette from "../../../theme/palette.js";
import typography from "../../../theme/typography.js";

const SettingsFooter = ({ isAuthUser, openModal }) => {
  return (
    <div className="settings-footer">
      {isAuthUser ? (
        <Button
          onClick={openModal}
          to="#"
          style={{ color: palette.primary.main }}
        >
          Видалити профіль
        </Button>
      ) : (
        <Button variant="contained">
          <Typography sx={{ ...typography.body1, padding: "0 40px" }}>
            Створити профіль
          </Typography>{" "}
          <ArrowForwardIcon />
        </Button>
      )}
    </div>
  );
};
export default SettingsFooter;
