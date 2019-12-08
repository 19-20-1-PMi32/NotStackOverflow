import * as React from 'react';
import { Formik, Form, Field } from 'formik';

import { InputField, Button, H2 } from 'components';
import { styled } from 'theme';
import { validationUtil } from 'utils';
import { HandleSignupAction } from 'store/domains';

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

interface ISignupFrom {
  handleSignupAction: HandleSignupAction;
}

const SignUpForm: React.FC<ISignupFrom> = ({ handleSignupAction }) => {
  return (
    <Wrapper>
      <H2 className="title">Sign up to NotStackOverflow</H2>
      <Formik
        initialValues={{
          name: '',
          surname: '',
          username: '',
          email: '',
          password: '',
          confirmPassword: ''
        }}
        onSubmit={(values) => {
          console.log(values)
          handleSignupAction(values);
        }}
      >{({ isValid }) => (
        <Form>
          <Field
            component={InputField}
            label="Name"
            name="name"
            placeholder="Enter your name"
            validate={validationUtil.required}
          />
          <Field
            component={InputField}
            label="Surname"
            name="surname"
            placeholder="Enter your surname"
            validate={validationUtil.required}
          />
          <Field
            component={InputField}
            label="Username"
            name="username"
            placeholder="Enter your username"
            validate={validationUtil.required}
          />
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
          <Field
            component={InputField}
            label="Confirm password"
            name="confirmPassword"
            placeholder="Confirm your password"
            validate={validationUtil.required}
            type="password"
          />
          <Button className="submit-button" type="submit">Sign up</Button>
        </Form>
      )}
      </Formik>
    </Wrapper>
  )
};

export default SignUpForm;
