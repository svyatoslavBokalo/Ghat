import ReactDOM from "react-dom/client";
import { Provider } from "react-redux";
import store from "./app/store/store";
import App from "./app/App";
import "./index.scss";
import { applyPrimaryColor } from "./theme";
import palette from "./theme/palette";

ReactDOM.createRoot(document.getElementById("root")).render(
  <Provider store={store}>
    <App />
  </Provider>,
);

applyPrimaryColor(palette.primary.main);
