import { Grid } from "@mui/material";
import "./Main.scss";

const imageUrl =
  "https://news.artnet.com/app/news-upload/2019/01/Cat-Photog-Feat-256x256.jpg";
const rows = [1, 2, 3, 4, 5, 6]; // 5 рядів
const itemsPerRow = 3;

const MainLobby = () => {
  return (
    <div>
      <div style={{ textAlign: "left" }}>
        <strong> Найпопулярніші теми </strong>
      </div>

      {rows.map((row) => (
        <Grid container spacing={1} key={row}>
          {[...Array(itemsPerRow)].map((_, index) => (
            // eslint-disable-next-line react/no-array-index-key
            <Grid item xs={4} key={index}>
              <img alt=" " className="cat-img" src={imageUrl} />
            </Grid>
          ))}
        </Grid>
      ))}
    </div>
  );
};
export default MainLobby;
