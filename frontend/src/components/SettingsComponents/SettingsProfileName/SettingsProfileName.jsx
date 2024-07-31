import { Grid, Typography } from "@mui/material";
import typography from "../../../theme/typography.js";
import palette from "../../../theme/palette.js";
import "./SettingsProfileName.scss";

const SettingsProfileName = () => {
  return (
    <Grid item sx={{ marginLeft: "15px" }}>
      <div className="settings-profile-name">
        <Typography variant="h6" sx={{ flex: 1, ...typography.body1 }}>
          Alina
        </Typography>
        <Typography variant="body2" sx={{ color: palette.grey[250] }}>
          @jacob_d
        </Typography>
      </div>
    </Grid>
  );
};
export default SettingsProfileName;
