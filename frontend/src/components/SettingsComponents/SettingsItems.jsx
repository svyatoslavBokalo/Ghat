import { Grid } from "@mui/material";
import SettingsItem from "./SettingsItem.jsx";
import { SETTINGS_ITEM_STYLES } from "../../app/constants.js";

const SettingsItems = () => {
  return (
    <Grid>
      <SettingsItem itemData={SETTINGS_ITEM_STYLES.LANGUAGE} />
      <div className="separator" style={{ marginLeft: "64px" }} />
      <SettingsItem itemData={SETTINGS_ITEM_STYLES.THEME} />
      <div style={{ marginTop: "22px" }}>
        <SettingsItem itemData={SETTINGS_ITEM_STYLES.INFO} />
      </div>
    </Grid>
  );
};
export default SettingsItems;
