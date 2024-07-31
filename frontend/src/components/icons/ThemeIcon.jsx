import FormatPaintIcon from "@mui/icons-material/FormatPaint";
import palette from "../../theme/palette.js";
import BaseIcon from "./BaseIcon.jsx";

const ThemeIcon = () => {
  const backgroundColor = { backgroundColor: palette.secondary.main };

  return <BaseIcon params={backgroundColor} name={FormatPaintIcon} />;
};
export default ThemeIcon;
