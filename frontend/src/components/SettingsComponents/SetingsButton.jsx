import Button from "@mui/material/Button";
import SettingsIcon from "@mui/icons-material/Settings";
import { useNavigate } from "react-router-dom";

const SetingsButton = () => {
  const navigate = useNavigate();

  const handleOpen = () => {
    navigate("/settings");
  };

  return (
    <div>
      <Button onClick={handleOpen}>
        <SettingsIcon />
      </Button>
    </div>
  );
};
export default SetingsButton;
