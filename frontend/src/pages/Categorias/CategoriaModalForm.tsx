import { useEffect, useState } from "react"
import { Modal, Button, Form } from "react-bootstrap"
import { useForm } from "react-hook-form"
import api from "../../services/api"
import type { ApiResponse } from "../../interfaces/ApiResponse"
import type { FinalidadeCategoria } from "../../interfaces/FinalidadeCategoria"
import { showError, showSuccess } from "../../services/toast"

interface Props {
  show: boolean
  onClose: () => void
  onSaved: () => void
}

interface CategoriaForm {
  descricao: string
  finalidade: number
}

function CategoriaModalForm({
  show,
  onClose,
  onSaved
}: Props) {

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting }
  } = useForm<CategoriaForm>()

  const [finalidades, setFinalidades] = useState<FinalidadeCategoria[]>([])

  async function fetchFinalidades() {
    const response = await api.get<ApiResponse<FinalidadeCategoria[]>>("/categoria/finalidades")

    if (response.data.isSuccess) {
      setFinalidades(response.data.data)
    } else {
      showError(response.data.messages.join("\n"))
    }
  }

  useEffect(() => {
    if (show) {
      reset({
        descricao: "",
        finalidade: 0
      })

      // eslint-disable-next-line react-hooks/set-state-in-effect
      fetchFinalidades()
    }
  }, [show, reset])

  async function onSubmit(data: CategoriaForm) {
    const response = await api.post<ApiResponse<unknown>>("/categoria", data)

    if (response.data.isSuccess) {
      showSuccess("Categoria criada com sucesso.")
      onClose()
      onSaved()
    } else {
      showError(response.data.messages.join("\n"))
    }
  }

  return (
    <Modal show={show} onHide={onClose}>
      <Form onSubmit={handleSubmit(onSubmit)}>
        <Modal.Header closeButton>
          <Modal.Title>
            Nova Categoria
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <Form.Group className="mb-3">
            <Form.Label>
              Descrição <span className="text-danger">*</span>
            </Form.Label>
            <Form.Control
              autoFocus
              isInvalid={!!errors.descricao}
              {...register("descricao", {
                required: "Descrição é obrigatória"
              })}
            />
            <Form.Control.Feedback type="invalid">
              {errors.descricao?.message}
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group>
            <Form.Label>
              Finalidade <span className="text-danger">*</span>
            </Form.Label>
            <Form.Select
              isInvalid={!!errors.finalidade}
              {...register("finalidade", {
                required: "Finalidade é obrigatória",
                valueAsNumber: true
              })}
            >
              <option value="">Selecione...</option>
              {finalidades.map((f) => (
                <option key={f.id} value={f.id}>
                  {f.descricao}
                </option>
              ))}
            </Form.Select>
            <Form.Control.Feedback type="invalid">
              {errors.finalidade?.message}
            </Form.Control.Feedback>
          </Form.Group>

        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary" onClick={onClose} >
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

export default CategoriaModalForm