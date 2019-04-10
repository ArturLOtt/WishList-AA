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
      <div className="App">
        <div>
          <div className="tela-quadrada-invisivel">
            <form onSubmit={this.efetuarLogin.bind(this)}>
              <div className="form-group">
                <label htmlFor="exampleInputEmail1">Email</label>
                <input
                  type="email"
                  className="form-control"
                  id="login-email"
                  aria-describedby="emailHelp"
                  placeholder="Insira seu email"
                  value={this.state.email}
                  onChange={this.atualizarStateEmail.bind(this)}
                />
                <label htmlFor="exampleInputPassword1">Password</label>
                <input
                  type="password"
                  className="form-control"
                  id="login-pass"
                  placeholder="Insira sua senha"
                  value={this.state.pass}
                  onChange={this.atualizarStateSenha.bind(this)}
                />
                <button type="submit" className="btn btn-primary">
                  Submit
                </button>
                <small>Não tem um cadastro?</small>
              </div>
            </form>
          </div>
        </div>
      </div>
    );
  }
}

export default App;
