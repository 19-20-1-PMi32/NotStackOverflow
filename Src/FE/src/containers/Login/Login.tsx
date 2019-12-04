import * as React from 'react';
import { Formik, Form, Field } from 'formik';

import { InputField, Button, H2 } from 'components';
import { styled } from 'theme';
import { validationUtil } from 'utils';

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

const LoginForm = () => {
  return (
    <Wrapper>
      <H2 className="title">Login to NotStackOverflow</H2>
      <Formik
        initialValues={{
          login: '',
          password: ''
        }}
        onSubmit={() => undefined}
      >{() => (
        <Form>
          <Field
            component={InputField}
            label="Email"
            name="login"
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
