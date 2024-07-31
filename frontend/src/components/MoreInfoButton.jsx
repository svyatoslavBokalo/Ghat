import { IconButton } from "@mui/material";
import InfoIcon from "@mui/icons-material/Info";
import palette from "../theme/palette";

const containerStyles = {
  display: "flex",
  justifyContent: "end",
};

const ButtonStyles = {
  margin: "34px 40px 10px 0",
  opacity: "60%",
};

const MoreInfoButton = () => (
  <div style={containerStyles}>
    <IconButton size="large" sx={ButtonStyles} aria-label="More information">
      <InfoIcon
        sx={{
          color: palette.secondary.main,
          fontSize: "30px",
          "& path": { transform: "translate(-2.5px, -2.5px) scale(1.2)" },
        }}
      />
    </IconButton>
  </div>
);

export default MoreInfoButton;
