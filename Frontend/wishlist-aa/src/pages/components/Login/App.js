import React, { Component } from "react";
import "./App.css";
import Axios from "axios";

class App extends Component {
  constructor(){
    super();
    this.state = {
        email : '',
        senha : ''
        
    }
}

atualizarStateEmail(event){  this.setState({ email : event.target.value}); }
atualizarStateSenha(event){  this.setState({ senha : event.target.value}); }


efetuarLogin(event){
  event.preventDefault();
  
  Axios.post("http://localhost:5000/api/login", {
     email : this.state.email,
     senha: this.state.senha
  })
  .then(data => {
      if(data.status === 200){
          console.log(data);
          localStorage.setItem("usuario", data.data.token);
          this.props.history.push("/listar");
      } 
  })
  .catch(erro => { this.setState({ erroMensagem : 'Email ou senha inválido'});  })
}

  render() {
    return (
      <body>
      <div className="App">
      <div className="container">
        <div className="row">
          <div className="col-sm-9 col-md-7 col-lg-5 mx-auto">
            <div className="card card-signin my-5 tela-quadrada-invisivel">
              <div className="card-body ">
                <h5 className="card-title text-center cor">Logar</h5>
                <form className="form-signin" onSubmit={this.efetuarLogin.bind(this)}>
                  <div className="form-group">
                    <label htmlFor="inputEmail" className="cor">Email</label>
                    <input
                      type="email"
                      className="form-control"
                      id="login-email"
                      aria-describedby="emailHelp"
                      placeholder="Insira seu email"
                      value={this.state.email}
                      onChange={this.atualizarStateEmail.bind(this)}
                    />
                    <br/>
                    <div className="form-label-group">
                    <label htmlFor="inputPassword" className="cor">Password</label>
                    <input
                      type="password"
                      className="form-control"
                      id="login-pass"
                      placeholder="Insira sua senha"
                      value={this.state.pass}
                      onChange={this.atualizarStateSenha.bind(this)}
                    />
                    </div>
                    <br/>
                    <button type="submit" className="btn btn-lg btn-primary btn-block text-uppercase">
                      Submit
                    </button>
                    <small  className="cor2">Não tem um cadastro?</small>
                  </div>
            </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
      </body>
    );
  }
}

export default App;
