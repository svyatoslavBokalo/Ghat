import { SETTINGS_ITEM_STYLES } from "../../app/constants.js";
import LangIcon from "./LangIcon.jsx";
import ThemeIcon from "./ThemeIcon.jsx";
import InfoIcon from "./InfoIcon.jsx";

const IconFactory = ({ itemData }) => {
  let IconComponent;

  switch (itemData) {
    case SETTINGS_ITEM_STYLES.LANGUAGE:
      IconComponent = LangIcon;
      break;
    case SETTINGS_ITEM_STYLES.THEME:
      IconComponent = ThemeIcon;
      break;
    case SETTINGS_ITEM_STYLES.INFO:
      IconComponent = InfoIcon;
      break;
    default:
      IconComponent = " ";
  }

  return <IconComponent />;
};
export default IconFactory;
