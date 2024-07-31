import { Grid } from "@mui/material";
import "./SubMenu.scss";
import palette from "../../theme/palette.js";

const SubMenu = ({ props }) => {
  if (!props) {
    return undefined;
  }
  const colorMap = {
    Світла: palette.secondary.main,
    Заблокувати: palette.error.main,
    default: "inherit",
  };

  return (
    <Grid
      className="settings-item-modal"
      sx={{ backgroundColor: palette.grey["50"] }}
    >
      {props &&
        props.map((el, i, arr) => (
          <Grid
            key={el}
            item
            className="settings-item-modal-language"
            style={
              i !== arr.length - 1
                ? { borderBottom: "1px solid #DDE2E580" }
                : {}
            }
          >
            <span style={{ color: colorMap[el] || colorMap.default }}>
              {el}
            </span>
          </Grid>
        ))}
    </Grid>
  );
};
export default SubMenu;
