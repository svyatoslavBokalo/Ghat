import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  // тут можуть бути ваші початкові налаштування
};

const settingsSlice = createSlice({
  name: 'settings',
  initialState,
  reducers: {
    // тут можуть бути ваші ред'юсери
  },
  // extraReducers може бути додано, якщо потрібно відгукнутися на дії інших слайсів
});

// Експорт ред'юсерів для використання в компонентах
// export const { someAction } = settingsSlice.actions;

export default settingsSlice.reducer;
