import { createTheme } from "@mui/material/styles";
import palette from "./palette";
import typography from "./typography";
import componentsOverride from "./components";

const theme = createTheme({
  palette,
  typography,
  components: componentsOverride,
});

export default theme;

export const applyPrimaryColor = (color) => {
  const root = document.getElementById("root");
  root.style.setProperty("--primary-color", color);
};
