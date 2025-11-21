// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
#pragma once

#include <cstdint>

extern thread_local char *torch_last_err;

//typedef torch::Tensor *Tensor;
struct OpaqueTensor;
typedef OpaqueTensor* Tensor;

//typedef torch::Scalar *Scalar;
struct OpaqueScalar;
typedef OpaqueScalar* Scalar;

//typedef torch::Generator* Generator;
struct OpaqueGenerator;
typedef OpaqueGenerator* Generator;

//typedef torch::nn::utils::rnn::PackedSequence* PackedSequence;
struct OpaquePackedSequence;
typedef OpaquePackedSequence* PackedSequence;

//typedef std::shared_ptr<torch::autograd::SavedVariable> * SavedVariable;
struct OpaqueSavedVariable;
typedef OpaqueSavedVariable* SavedVariable;

//typedef std::shared_ptr<torch::nn::Module> * NNModule;
struct OpaqueNNModule;
typedef OpaqueNNModule* NNModule;

//typedef std::shared_ptr<torch::nn::AnyModule> * NNAnyModule;
struct OpaqueNNAnyModule;
typedef OpaqueNNAnyModule* NNAnyModule;

//typedef std::shared_ptr<torch::optim::Optimizer> * Optimizer;
struct OpaqueOptimizer;
typedef OpaqueOptimizer* Optimizer;

//typedef std::shared_ptr<torch::jit::CompilationUnit> * JITCompilationUnit;
struct OpaqueJITCompilationUnit;
typedef OpaqueJITCompilationUnit* JITCompilationUnit;

//typedef std::shared_ptr<torch::jit::Module>* JITModule;
struct OpaqueJITModule;
typedef OpaqueJITModule* JITModule;

//typedef std::shared_ptr<torch::jit::Method>* JITMethod;
struct OpaqueJITMethod;
typedef OpaqueJITMethod* JITMethod;

//typedef std::shared_ptr<c10::Type> * JITType;
struct OpaqueJITType;
typedef OpaqueJITType* JITType;

//typedef std::shared_ptr<c10::TensorType>* JITTensorType;
struct OpaqueJITTensorType;
typedef OpaqueJITTensorType* JITTensorType;

//typedef torch::InferenceMode* InferenceMode;
struct OpaqueInferenceMode;
typedef OpaqueInferenceMode* InferenceMode;

struct TensorArray {
    Tensor *array;
    int64_t size;
};
