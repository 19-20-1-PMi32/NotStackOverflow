import * as React from 'react';
import { Formik, Form, Field } from 'formik';

import { InputField, Button, H2 } from 'components';
import { styled } from 'theme';
import { validationUtil } from 'utils';
import { HandleLoginAction } from 'store/domains';
import { HandleGetUserInfoAction } from 'store/domains/user';

const Wrapper = styled.div`
  max-width: 450px;
  margin: 0 auto;
  text-align: center;
  padding: 0 40px;
  margin-top: 100px;

  .title {
    margin-bottom: 20px;
  }

  .form-field {
    margin-bottom: 10px;
    text-align: left;
  }

  .submit-button {
    margin: 10px auto;
    width: 100%;
  }
`;

interface ILoginForm {
  handleLoginAction: HandleLoginAction;
  handleGetUserInfoAction: HandleGetUserInfoAction;
}

const LoginForm: React.FC<ILoginForm> = ({ handleLoginAction, handleGetUserInfoAction }) => {
  return (
    <Wrapper>
      <H2 className="title">Login to NotStackOverflow</H2>
      <Formik
        initialValues={{
          email: '',
          password: ''
        }}
        onSubmit={async (values) => {
          await handleLoginAction(values.email, values.password);
          handleGetUserInfoAction();
        }}
      >{() => (
        <Form>
          <Field
            component={InputField}
            label="Email"
            name="email"
            placeholder="Enter your email"
            validate={validationUtil.required}
          />
          <Field
            component={InputField}
            label="Password"
            name="password"
            placeholder="Enter your password"
            validate={validationUtil.required}
            type="password"
          />
          <Button className="submit-button" type="submit">Login</Button>
        </Form>
      )}
      </Formik>
    </Wrapper>
  )
};

export default LoginForm;
