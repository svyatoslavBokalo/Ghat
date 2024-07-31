import { Grid, IconButton, Typography } from "@mui/material";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import { useState } from "react";
import typography from "../../theme/typography.js";
import palette from "../../theme/palette.js";
import IconFactory from "../icons/IconFactory.jsx";
import SubMenu from "../SubMenu/SubMenu.jsx";
import { SETTINGS_ITEM_STYLES } from "../../app/constants.js";

const SettingsItem = ({ itemData }) => {
  const [isArrowRight, setIsArrowRight] = useState(true);
  const [isSubMenuOpen, setIsSubMenuOpen] = useState(false);

  const languages = ["Українська", "English"];
  const themes = ["Світла", "Темна"];

  const isThemeStyle = itemData === SETTINGS_ITEM_STYLES.THEME;
  const isLanguageStyle = itemData === SETTINGS_ITEM_STYLES.LANGUAGE;

  // додати
  // const isInfoStyle = itemData === SETTINGS_ITEM_STYLES.INFO;

  const onSettingsItemClick = () => {
    setIsArrowRight((prevIsArrowRight) => !prevIsArrowRight);
    setIsSubMenuOpen((prevIsSubMenuOpen) => !prevIsSubMenuOpen);
  };

  const onIconButtonClick = (event) => {
    event.stopPropagation();
    onSettingsItemClick();
  };

  return (
    <Grid
      container
      justifyContent="space-between"
      alignItems="center"
      sx={{
        backgroundColor: palette.grey["50"],
        padding: "7px 7px 7px 20px",
        cursor: "pointer",
      }}
      onClick={onSettingsItemClick}
    >
      <Grid sx={{ display: "flex", alignItems: "center" }}>
        <IconFactory itemData={itemData} />
        <Typography
          sx={{
            marginLeft: "16px",
            ...typography.body2,
          }}
        >
          {itemData}
        </Typography>
      </Grid>
      <Grid container sx={{ width: "40px", position: "relative" }}>
        <IconButton
          sx={{
            color: palette.grey["350"],
            "&:hover": {
              backgroundColor: "transparent",
            },
          }}
          onClick={onIconButtonClick}
        >
          {isArrowRight ? (
            <KeyboardArrowRightIcon />
          ) : (
            <KeyboardArrowDownIcon />
          )}
        </IconButton>
        {isSubMenuOpen && (
          <SubMenu
            props={
              (isThemeStyle && themes) || (isLanguageStyle && languages) || null
            }
          />
        )}
      </Grid>
    </Grid>
  );
};
export default SettingsItem;
