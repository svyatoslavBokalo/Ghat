import { Link } from "react-router-dom";
import { Button, Typography, useTheme } from "@mui/material";
import { useState } from "react";

import GetNameModal from "../../components/GetNameModal/GetNameModal";
import MoreInfoButton from "../../components/MoreInfoButton";
import HappyPeople from "../../assets/1st_screen_pic.png";
import { MODAL_MODES } from "../../app/constants";

import "./StartFlow.scss";

function StartFlow() {
  const [showModal, setShowModal] = useState(false);
  const [flow, setFlow] = useState(null);
  const theme = useTheme();

  const toShowModal = (flowType) => {
    setFlow(flowType);
    setShowModal(true);
  };

  return (
    <div className="start-flow">
      <div className="start-flow__main">
        <img src={HappyPeople} alt="" className="start-flow__image" />
      </div>

      <div className="start-flow__bottom">
        <div className="start-flow__description">
          <Typography
            className="start-flow__title"
            sx={{ ...theme.typography.h1Bold }}
          >
            <span className="start-flow__title-part">LDIS</span> Live Discussion
          </Typography>
          <Typography variant="body1">
            Привіт, готовий до найкращого спілкування в своєму житті?
          </Typography>
        </div>

        <div className="start-flow__buttons">
          <Button
            onClick={() => toShowModal(MODAL_MODES.CHOOSE)}
            variant="contained"
            sx={{ width: "330px" }}
          >
            Продовжити без реєстрації
          </Button>

          <div>
            <Link to="/auth">
              <Button
                variant="outlined"
                size="small"
                sx={{ marginRight: "10px" }}
              >
                Вхід
              </Button>
            </Link>

            <Link to="/auth" state={{ stage: "registration" }}>
              <Button variant="outlined" size="small">
                Реєстрація
              </Button>
            </Link>
          </div>
        </div>

        <MoreInfoButton />
      </div>

      {showModal && (
        <GetNameModal handleClose={() => setShowModal(false)} flow={flow} />
      )}
    </div>
  );
}

export default StartFlow;
