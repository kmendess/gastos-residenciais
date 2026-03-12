import { useEffect } from "react"
import { Modal, Button, Form } from "react-bootstrap"
import { useForm } from "react-hook-form"
import api from "../../services/api"
import type { Pessoa } from "../../interfaces/Pessoa"
import type { ApiResponse } from "../../interfaces/ApiResponse"
import { showError, showSuccess } from "../../services/toast"

interface Props {
  show: boolean
  pessoa: Pessoa | null
  onClose: () => void
  onSaved: () => void
}

interface PessoaForm {
  nome: string
  idade?: number
}

function PessoaModalForm({
  show,
  pessoa,
  onClose,
  onSaved
}: Props) {

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting }
  } = useForm<PessoaForm>()

  const isEdit = !!pessoa

  useEffect(() => {
    if (show) {
      if (pessoa) {
        reset({
          nome: pessoa.nome,
          idade: pessoa.idade
        })
      } else {
        reset({
          nome: "",
          idade: undefined
        })
      }
    }
  }, [show, pessoa, reset])

  function handleClose() {
    reset()
    onClose()
  }

  async function onSubmit(data: PessoaForm) {
    let response

    if (isEdit) {
      response = await api.put<ApiResponse<unknown>>(`/pessoa/${pessoa?.id}`, data)
    } else {
      response = await api.post<ApiResponse<unknown>>("/pessoa", data)
    }

    if (response.data.isSuccess) {
      showSuccess(
        isEdit
          ? "Pessoa atualizada com sucesso."
          : "Pessoa criada com sucesso."
      )

      handleClose()
      onSaved()
    } else {
      showError(response.data.messages.join("\n"))
    }
  }

  return (
    <Modal show={show} onHide={handleClose}>
      <Form onSubmit={handleSubmit(onSubmit)}>
        <Modal.Header closeButton>
          <Modal.Title>
            {isEdit ? "Editar Pessoa" : "Nova Pessoa"}
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <Form.Group className="mb-3">
            <Form.Label>
              Nome <span className="text-danger">*</span>
            </Form.Label>
            <Form.Control
              autoFocus
              isInvalid={!!errors.nome}
              {...register("nome", {
                required: "Nome é obrigatório"
              })}
            />
            <Form.Control.Feedback type="invalid">
              {errors.nome?.message}
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group>
            <Form.Label>
              Idade <span className="text-danger">*</span>
            </Form.Label>

            <Form.Control
              type="number"
              min={0}
              max={130}
              isInvalid={!!errors.idade}
              {...register("idade", {
                required: "Idade é obrigatória",
                min: { value: 0, message: "Idade mínima é 0" },
                max: { value: 130, message: "Idade máxima é 130" },
                valueAsNumber: true
              })}
            />

            <Form.Control.Feedback type="invalid">
              {errors.idade?.message}
            </Form.Control.Feedback>
          </Form.Group>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Cancelar
          </Button>

          <Button type="submit" variant="primary" disabled={isSubmitting}>
            {isSubmitting ? "Salvando..." : "Salvar"}
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>
  )
}

export default PessoaModalForm