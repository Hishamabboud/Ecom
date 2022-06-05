import {createStore} from "redux";
import rootReducers from './Reducer/index'

const store = createStore(rootReducers);

export default store;