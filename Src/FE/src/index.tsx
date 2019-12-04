import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { Route } from 'react-router';

import GlobalStyles from './theme/global';
import { ThemeProvider, theme } from 'theme';
import store, { history } from 'store';

import * as serviceWorker from './serviceWorker';

import Root from './containers/Root';

ReactDOM.render(
  (
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <ThemeProvider theme={theme}>
        <GlobalStyles />
        <Root />
      </ThemeProvider>
    </ConnectedRouter>
  </Provider>
  ), 
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
