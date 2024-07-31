import { Grid } from "@mui/material";
import "./Settings.scss";
import { useState } from "react";
import SettingsFooter from "../../components/SettingsComponents/SettingsFooter/SettingsFooter.jsx";
import ProfileHeader from "../../components/SettingsComponents/ProfileHeader.jsx";
import SettingsItems from "../../components/SettingsComponents/SettingsItems.jsx";
import UserAvatar from "../../components/UserInfoComponents/UserAvatar.jsx";
import SettingsProfileName from "../../components/SettingsComponents/SettingsProfileName/SettingsProfileName.jsx";
import { PROFILE_HEADER_TITLES } from "../../app/constants.js";
import ModalDelete from "../../components/modals/ModalsSubmit.jsx";
import modalConstnats from '../../app/constants/modals.js';

const Settings = ({ isAuthUser = true }) => {
  const [modal, setModal] = useState(false);

  const openModal = () => {
    setModal(true);
  };

  const closeModal = () => {
    setModal(false);
  };
  return (
    <Grid
      container
      direction="column"
      justifyContent="space-between"
      height="100vh"
      padding="8px 0"
    >
      <div>
        <ProfileHeader title={PROFILE_HEADER_TITLES.SETTINGS} />
        <Grid
          container
          justifyContent="start"
          alignItems="center"
          sx={{ marginTop: "13px", marginBottom: "13px", paddingLeft: "15px" }}
        >
          <UserAvatar />
          <SettingsProfileName />
        </Grid>
        <Grid>
          <div className="separator" />
          <SettingsItems />
        </Grid>
      </div>

      <div>
        <SettingsFooter openModal={openModal} isAuthUser={isAuthUser} />
      </div>
      <ModalDelete
        type={modalConstnats.deleteChatUser}
        show={modal}
        onClose={closeModal}
      />
    </Grid>
  );
};
export default Settings;
