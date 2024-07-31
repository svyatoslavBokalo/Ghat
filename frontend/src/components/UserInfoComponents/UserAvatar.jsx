import Avatar from "@mui/material/Avatar";
import { Grid } from "@mui/material";

const UserAvatar = () => {
  return (
    <Grid item>
      <Avatar alt="userName" sx={{ width: 66, height: 66 }} />
    </Grid>
  );
};
export default UserAvatar;
