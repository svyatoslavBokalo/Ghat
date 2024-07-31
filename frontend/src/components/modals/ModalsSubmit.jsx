import { useEffect, useState } from "react";
import "./ModalsSubmit.scss";
import modalType from "./ModalType";
import UserPhotoMock from "../../../public/userPhotoMock.svg";
const ModalsSubmit = ({ type, show, onClose }) => {
  const [showModal, setShowModal] = useState(false);
  useEffect(() => {
    setShowModal(show);
  }, [show]);
  const closeModal = () => {
    setShowModal(false);
    if (onClose) {
      onClose();
    }
  };
  return (
    showModal && (
      <div onClick={closeModal} className="modal-background">
        <div onClick={(e) => e.stopPropagation()} className="modal">
          <div className="modal-content">
            <button className="background-svg">
              <input className="uploadFile--input" type="file" />
              <img src={UserPhotoMock} alt="mock-User-Avatar" />
            </button>
            {modalType[type]}
          </div>
          <button onClick={closeModal} className="decline-btn">
            Скасувати
          </button>
        </div>
      </div>
    )
  );
};
export default ModalsSubmit;
