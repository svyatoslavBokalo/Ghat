import "./HeaderLobbyIcons.scss";
import ForumIcon from "@mui/icons-material/Forum";
import { Button } from "@mui/material";
import SetingsButton from "../SettingsComponents/SetingsButton.jsx";

const HeaderLobbyIcons = () => {
  return (
    <div className="Header">
      <div>
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="39"
          height="37"
          viewBox="0 0 39 37"
          fill="none"
        >
          <path
            fillRule="evenodd"
            clipRule="evenodd"
            d="M19.52 37C30.146 37 38.76 28.7173 38.76 18.5C38.76 8.28273 30.146 0 19.52 0C8.89407 0 0.280029 8.28273 0.280029 18.5C0.280029 28.7173 8.89407 37 19.52 37Z"
            fill="url(#paint0_linear_7_3444)"
          />
          <defs>
            <linearGradient
              id="paint0_linear_7_3444"
              x1="19.52"
              y1="0"
              x2="19.52"
              y2="37"
              gradientUnits="userSpaceOnUse"
            >
              <stop />
              <stop offset="1" stopColor="#C5C5C5" stopOpacity="0" />
            </linearGradient>
          </defs>
        </svg>
      </div>
      <div style={{ display: "flex" }}>
        <Button>
          <div style={{ display: "block" }}>
            <ForumIcon />
          </div>
        </Button>
        <SetingsButton />
      </div>
    </div>
  );
};

export default HeaderLobbyIcons;
