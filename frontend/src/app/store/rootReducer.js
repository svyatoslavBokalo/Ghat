import { combineReducers } from '@reduxjs/toolkit';
import counterSlice from './counter/counterSlice';
import settingsSlice from './settings/settingsSlice';

const rootReducer = combineReducers({
  counter: counterSlice,
  settings: settingsSlice,
});

export default rootReducer;
