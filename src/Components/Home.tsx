import  { FC } from "react";
import { RouteComponentProps,NavLink } from "react-router-dom";
import "./home.css";
import axios from "axios";
import {  toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.min.css";
import "datatables.net";
import "datatables.net-fixedheader";
import $ from "jquery";
import { useForm } from "react-hook-form";
import Modal from "./Modal";
import useModal from "./useModel";
import "../styles.css";
type SomeComponentProps = RouteComponentProps;
const Home: FC<SomeComponentProps> = ({ history }) => 
{
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();
  const { isOpen, toggle } = useModal();
  const logout = () => {
    localStorage.clear();
    history.push("/login");
  };

  var table = $('#list').DataTable();
  table.destroy();
   axios
      .get("https://localhost:7087/api/ToDoApp/"+history.location.state)
      .then(function (response) {
          toast.success(response.data.message, {
            position: "top-right",
            autoClose: 3000,
            hideProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: false,
            progress: 0,
            toastId: "my_toast",
          });
        console.log(response.data);
      table= $('#list').DataTable({
          data: response.data.list,
          paging: false,
          searching: false,
          retrieve: true,
          destroy: true,
          columns: [
              { data: 'todoId' },
              { data: 'title' },
              { data: 'detail' },   
              ]
        })
        
      })
      .catch(function (error) {
        console.log(error);
      });
    $('#update').off().on('click', function(){
      
    });
    const submitDelete = (data: any) => {
      console.log(data.Password);
    axios
      .delete("https://localhost:7087/api/ToDoApp/"+data.Password)
      .then(function (response) {
        toast.success(response.data.message, {
          position: "top-right",
          autoClose: 3000,
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: false,
          progress: 0,
          toastId: "my_toast",
        });
        reset();
      })
      .catch(function (error) {
        console.log(error);
      });
  };
  const  title = document.getElementById('title-todo') as HTMLInputElement;
  const detail = document.getElementById('detail-todo') as HTMLInputElement;
  

    const submitAdd = () => {
      let todo = {
        title:title.value,
        detail:detail.value,
        userIdFK: history.location.state
      }
      console.log(todo)
      axios
      .post("https://localhost:7087/api/ToDoApp", todo)
      .then(function (response) {
        toast.success(response.data.message, {
          position: "top-right",
          autoClose: 3000,
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: false,
          progress: 0,
          toastId: "my_toast",
        });
      })
      .catch(function (error) {
        console.log(error);
      });
      
   
  };
  return (
    <>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          paddingLeft: 50,
          paddingRight: 50,
        }}
      >
        <div>
          <h3 className="m-3">GÖREVLER</h3>
        </div>
        <div>
          <button type="submit" className="buttons" onClick={logout}>
            Çıkış
          </button>
        </div>
      </div>
      <div className="container">
        <div
          className="row d-flex justify-content-center align-items-center text-center"
          style={{ height: "80vh" }}
        >
        <table id ="list" className="table"><thead className="thead-dark"><tr>
        <th scope="col">Id</th>
        <th scope="col">Title</th>
        <th scope="col">Detail</th> 
        </tr></thead><tbody id = "body"></tbody></table>
        </div>
        <div className="">
        <button id='openAddModal' type="submit" className="buttons" onClick={toggle} >Yeni Bir Yapılacak Ekle</button>
        <Modal isOpen={isOpen} toggle={toggle}>
        <div>
        <label className="labels"> Başlık</label>
        <input type="text" id="title-todo"></input>
        <label className="labels">Detay</label>
        <input type="text" id="detail-todo"></input>
        <button id='add' type="submit" className="buttons" onClick={submitAdd} > Ekle</button>
        </div>
      </Modal>
        <label className="labels">  SİLMEK yada GÜNCELLEMEK istediğiniz ID'yi giriniz ve yapmak istediğiniz İŞLEME TIKLAYINIZ.</label>
        <input type="text" id="id-todo" className="textboxs" {...register("Password", {required: "Password is required!", })}></input>
        <button id='update' type="submit" className="buttons" >Güncelle</button>
        <button id='delete' type="submit" className="buttons" onClick={handleSubmit(submitDelete)}>Sil</button>
        </div>
      </div>
    </>
  );
};

export default Home;