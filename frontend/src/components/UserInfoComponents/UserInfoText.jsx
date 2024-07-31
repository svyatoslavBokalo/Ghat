import { Grid, Typography } from "@mui/material";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";

const UserInfoText = ({ title, text }) => {
  return (
    <Grid
      container
      flexDirection="column"
      alignItems="flex-start"
      sx={{ padding: "10px 0 10px 30px" }}
    >
      <Grid item display="flex" flexDirection="column" alignItems="flex-start">
        <Typography sx={{ ...typography.caption, color: palette.grey["300"] }}>
          {title}
        </Typography>
        <Typography sx={{ flex: 1, ...typography.body1, textAlign: "left" }}>
          {text}
        </Typography>
      </Grid>
    </Grid>
  );
};

export default UserInfoText;
