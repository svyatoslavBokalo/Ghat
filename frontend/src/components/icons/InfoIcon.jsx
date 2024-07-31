import LockIcon from "@mui/icons-material/Lock";
import palette from "../../theme/palette.js";
import BaseIcon from "./BaseIcon.jsx";

const InfoIcon = () => {
  const backgroundColor = { backgroundColor: palette.grey["100"] };

  return <BaseIcon params={backgroundColor} name={LockIcon} />;
};
export default InfoIcon;
