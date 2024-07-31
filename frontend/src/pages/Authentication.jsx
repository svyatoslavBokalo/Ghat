import { useLocation, Link } from "react-router-dom";
import { Button, TextField } from "@mui/material";
import GoogleIcon from "@mui/icons-material/Google";

function Authentication() {
  const location = useLocation();
  const { state } = location;
  const isItRegistrationScreen = state && state.stage === "registration";

  return (
    <div>
      <p>Скоро тут буде чат</p>

      <div style={{ margin: "25px" }}>
        <TextField label="Ім’я користувача" variant="standard" />
      </div>

      <div style={{ margin: "25px" }}>
        <TextField label="Пароль" variant="standard" type="password" />
      </div>

      {isItRegistrationScreen && (
        <div style={{ margin: "25px" }}>
          <TextField
            label="Підтвердіть пароль"
            variant="standard"
            type="password"
          />
        </div>
      )}

      <div>
        <Link to="/">
          <Button variant="contained" sx={{ marginRight: "10px" }}>
            {(isItRegistrationScreen && "Продовжити") || "Вхід"}
          </Button>
        </Link>

        <Link to="/">
          <Button variant="contained">
            <GoogleIcon />
          </Button>
        </Link>
      </div>

      <br />
      {(isItRegistrationScreen && <RegistrationFooter />) || <LoginFooter />}
    </div>
  );
}

export default Authentication;

function RegistrationFooter() {
  return (
    <>
      <p>Вже є аккаунт?</p>
      <Link to="/auth">
        <p style={{ textDecoration: "underline" }}> Вхід </p>
      </Link>
      <br />
      <Link to="/">
        <Button variant="contained" sx={{ fontSize: "16px" }}>
          Назад
        </Button>
      </Link>
    </>
  );
}

function LoginFooter() {
  return (
    <>
      <p>Перший раз? ?</p>

      <Link to="/auth" state={{ stage: "registration" }}>
        <p style={{ textDecoration: "underline" }}> Зареєстуватись </p>
      </Link>

      <br />
      <Link to="/">
        <Button variant="contained" sx={{ fontSize: "16px" }}>
          Назад
        </Button>
      </Link>
    </>
  );
}
