import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import "./GetNameModal.scss";
import { MODAL_MODES } from "../../app/constants";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 310,
  bgcolor: "#808080",
  border: "2px solid #000",
  boxShadow: 24,
  p: 2,
};

const GetNameModal = ({ handleClose, flow }) => {
  const isChooseFlow = flow === MODAL_MODES.CHOOSE;

  return (
    <Modal open onClose={handleClose}>
      <Box sx={style}>
        <Typography id="modal-modal-title" variant="h6" component="h2">
          Як можна до тебе звертатись?
        </Typography>

        <TextField helperText="Це ім’я бачитимуть усі користувачі чату" />

        <Link to={(isChooseFlow && "/lobby") || "/chat/000"}>
          <Button variant="contained" onClick={handleClose}>
            {(isChooseFlow && "Здивуй мене") || "До спілкування!"}
          </Button>
        </Link>
      </Box>
    </Modal>
  );
};

export default GetNameModal;
