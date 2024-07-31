import { Button, Grid } from "@mui/material";
import ProfileHeader from "../../components/SettingsComponents/ProfileHeader.jsx";
import { PROFILE_HEADER_TITLES } from "../../app/constants.js";
import "../../components/UserInfoComponents/UserInfoFullName/UserInfoFullName.scss";
import palette from "../../theme/palette.js";
import { useState } from "react";
import ModalDelete from "../../components/modals/ModalsSubmit.jsx";
import UserInfoText from "../../components/UserInfoComponents/UserInfoText.jsx";
import UserInfoProfileDetails from "../../components/UserInfoComponents/UserInfoProfileDetails.jsx";
import modalConstnats from '../../app/constants/modals.js';
const UserInfo = () => {
  const [modal, setModal] = useState(false);

  const openModal = () => {
    setModal(true);
  };

  const closeModal = () => {
    setModal(false);
  };

  return (
    <Grid
      display="flex"
      flexWrap="nowrap"
      flexDirection="column"
      justifyContent="space-between"
      sx={{ height: "100vh" }}
    >
      <Grid>
        <ProfileHeader title={PROFILE_HEADER_TITLES.USER_INFO} />
        <UserInfoProfileDetails />
        <UserInfoText title="username" text="@username" />
        <UserInfoText
          title="bio"
          text="Design adds value faster, than it adds cost"
        />
        <Grid item style={{ margin: "88px 0 24px 0 " }}>
          <Button variant="contained" size="small" sx={{ marginRight: "10px" }}>
            Додати
          </Button>
        </Grid>
        <Grid item>
          <Button variant="contained" size="small" sx={{ marginRight: "10px" }}>
            Написати
          </Button>
        </Grid>
      </Grid>
      <Grid item sx={{ marginBottom: "56px" }}>
        <Button
          to="#"
          onClick={openModal}
          style={{ color: palette.error.main }}
        >
          Видалити профіль
        </Button>
      </Grid>
      <ModalDelete
        type={modalConstnats.deleteChatUser}
        show={modal}
        onClose={closeModal}
      ></ModalDelete>
    </Grid>
  );
};
export default UserInfo;
