import LanguageIcon from "@mui/icons-material/Language";
import palette from "../../theme/palette.js";
import BaseIcon from "./BaseIcon.jsx";

const LangIcon = () => {
  const backgroundColor = { backgroundColor: palette.primary.main };

  return <BaseIcon params={backgroundColor} name={LanguageIcon} />;
};
export default LangIcon;
